using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Updater.Core.Helpers
{
    public class DownloadFileHelper : IDownloadFileHelper
    {
        private const int BUFFER_SIZE = 8192;

        public async Task Start(string url, string filename, Action<bool, long> fncUpdateProgress, CancellationToken cancellationToken)
        {
            var client = new HttpClient();

            using var response = await GetResponseMessageAsync(client, url, cancellationToken);
            response.EnsureSuccessStatusCode();

            using Stream contentStream = await ReadContentAsStreamAsync(response, cancellationToken), fileStream = CreateFile(filename);

            var fileSize = GetContentLength(response.Content.Headers);

            await WriteInFile(fncUpdateProgress, fileSize, contentStream, fileStream, cancellationToken);
        }

        private static async Task WriteInFile(Action<bool, long> fncUpdateProgress, long fileSize, Stream contentStream, Stream fileStream, CancellationToken cancellationToken)
        {
            var totalRead = 0L;
            var buffer = new byte[BUFFER_SIZE];
            var isMoreToRead = true;

            do
            {
                var read = await contentStream.ReadAsync(buffer.AsMemory(0, buffer.Length), cancellationToken);
                if (read == 0)
                {
                    isMoreToRead = false;
                }
                else
                {
                    await fileStream.WriteAsync(buffer.AsMemory(0, read), cancellationToken);

                    totalRead += read;

                    fncUpdateProgress(true, totalRead * 100 / fileSize);
                }
            }
            while (isMoreToRead);
        }

        private static long GetContentLength(HttpContentHeaders headers)
            => headers.ContentLength ?? 1;

        private static async Task<HttpResponseMessage> GetResponseMessageAsync(HttpClient client, string url, CancellationToken cancellationToken)
            => await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        private static async Task<Stream> ReadContentAsStreamAsync(HttpResponseMessage response, CancellationToken cancellationToken)
            => await response.Content.ReadAsStreamAsync(cancellationToken);

        private static FileStream CreateFile(string filename)
            => new(filename, FileMode.Create, FileAccess.Write, FileShare.None, BUFFER_SIZE, true);
    }
}
using MeControla.AgileManager.Core.Data.Dto;
using MeControla.AgileManager.Core.Data.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Helpers
{
    public class ReadCFDFileExportHelper : IReadCFDFileExportHelper
    {
        private const string PATTERN_LINE_DATE = "Date";
        private const string PATTERN_LINE_TODO = "ToDo";
        private const string PATTERN_LINE_INPROGRESS = "InProgress";
        private const string PATTERN_LINE_DONE = "Done";
        private const string PATTERN_LINE_MONTHS = "Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec";
        private const string PATTERN_LINE = $"^\"(?<{PATTERN_LINE_DATE}>[W|w][0-9]{{2,}},\\s({PATTERN_LINE_MONTHS})\\s[0-9]{{2}}\\s[0-9]{{4}})\",(?<{PATTERN_LINE_DONE}>[0-9]+),(?<{PATTERN_LINE_INPROGRESS}>[0-9]+),(?<{PATTERN_LINE_TODO}>[0-9]+)";

        private readonly IDateTimeFromStringHelper dateTimeFromStringHelper;

        public ReadCFDFileExportHelper(IDateTimeFromStringHelper dateTimeFromStringHelper)
        {
            this.dateTimeFromStringHelper = dateTimeFromStringHelper;
        }

        public async Task<IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>>> GetData(string filename, CancellationToken cancellationToken)
        {
            var dataFile = await ReadDataFile(filename, cancellationToken);
            var toDoData = new List<CFDInfoDto>();
            var inProgressData = new List<CFDInfoDto>();
            var doneData = new List<CFDInfoDto>();

            foreach (var line in dataFile)
            {
                var data = GetDataLine(line);

                if (data == null)
                    continue;

                toDoData.Add(new() { Date = data.Item1, Value = data.Item2 });
                inProgressData.Add(new() { Date = data.Item1, Value = data.Item3 });
                doneData.Add(new() { Date = data.Item1, Value = data.Item4 });
            }

            return new Dictionary<EasyBIReportColumnName, IList<CFDInfoDto>>()
            {
                { EasyBIReportColumnName.ToDo, toDoData },
                { EasyBIReportColumnName.InProgress, inProgressData },
                { EasyBIReportColumnName.Done, doneData },
            };
        }

        private Tuple<DateTime, decimal?, decimal?, decimal?> GetDataLine(string line)
        {
            var regex = Regex.Match(line, PATTERN_LINE);
            if (!regex.Success)
                return null;

            var date = dateTimeFromStringHelper.Convert(regex.Groups[PATTERN_LINE_DATE].Value);
            var toDoData = (decimal?)Convert.ToDecimal(regex.Groups[PATTERN_LINE_TODO].Value);
            var inProgressData = (decimal?)Convert.ToDecimal(regex.Groups[PATTERN_LINE_INPROGRESS].Value);
            var doneData = (decimal?)Convert.ToDecimal(regex.Groups[PATTERN_LINE_DONE].Value);

            return Tuple.Create(date, toDoData, inProgressData, doneData);
        }

        private async static Task<string[]> ReadDataFile(string filename, CancellationToken cancellationToken)
            => IsValidFilename(filename)
             ? await File.ReadAllLinesAsync(filename, cancellationToken)
             : throw new ArgumentException($"File {filename} not found.");

        private static bool IsValidFilename(string filename)
            => !string.IsNullOrWhiteSpace(filename)
            && File.Exists(filename);
    }
}
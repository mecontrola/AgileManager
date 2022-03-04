using NSubstitute;
using NSubstitute.Core;
using System;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Tests.TestUtils.NSubstitute
{
    public static class ThrowExceptionExtensions
    {
        public static ConfiguredCall TaskThrowsException<T>(this Task<T> task, string message = null)
            => TaskThrows<T, Exception>(task, message);

        public static ConfiguredCall TaskThrows<T, TException>(this Task<T> task, string message = null)
            where TException : Exception
            => TaskThrows(task, typeof(TException), message);

        public static ConfiguredCall TaskThrows<T>(this Task<T> task, Type exceptionType, string message = null)
        {
            if (!typeof(Exception).IsAssignableFrom(exceptionType))
                throw new ArgumentException($"Type has to be a subclass of System.Exception", nameof(exceptionType));

            var exception = Activator.CreateInstance(exceptionType, message) as Exception;
            return TaskThrows(task, exception);
        }

        public static ConfiguredCall TaskThrows<T>(this Task<T> task, Exception exception)
            => task.Returns(Task.FromException<T>(exception));

        public static ConfiguredCall TaskThrows<TException>(this Task task, string message = null)
            where TException : Exception
            => TaskThrows(task, typeof(TException), message);

        public static ConfiguredCall TaskThrows(this Task task, Type exceptionType, string message = null)
        {
            if (!typeof(Exception).IsAssignableFrom(exceptionType))
                throw new ArgumentException($"Type has to be a subclass of System.Exception", nameof(exceptionType));

            var exception = Activator.CreateInstance(exceptionType, message) as Exception;
            return TaskThrows(task, exception);
        }

        public static ConfiguredCall TaskThrows(this Task task, Exception exception)
            => task.Returns(Task.FromException(exception));
    }
}

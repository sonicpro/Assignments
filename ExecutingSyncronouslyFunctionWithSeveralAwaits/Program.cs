using Nito.AsyncEx;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExecutingSyncronouslyFunctionWithSeveralAwaits
{
    class Program
    {
        static void Main(string[] args)
        {
            var startedAt = DateTime.Now;
            // This one does not return the execution until the MainRoutine returns, so the total execution time is 19 seconds.
            //AsyncContext.Run(async () => await MainRoutine());
            
            // Because this call is not awaited, the execution of the current method continues before the call is completed.
            // The total execution time is 3 seconds, the explanation is provided in the body of MainRoutine method.
            MainRoutine();
            var finishedAt = DateTime.Now;
            Console.WriteLine($"The whole process took {(finishedAt - startedAt).TotalSeconds}");
        }

        // Must execute in 
        static async Task SomeAsyncFunction()
        {
            var startedAt = DateTime.Now;
            await WaitForFiveSec();
            var finishedAt = DateTime.Now;
            Console.WriteLine($"You stupid, you missed all the show that took {(finishedAt - startedAt).TotalSeconds} seconds.");
        }

        // Produces five second delay
        static async Task WaitForFiveSec()
        {
            await Task.Delay(5000);
        }

        static async Task MainRoutine()
        {
            var startedAt = DateTime.Now;
            Thread.Sleep(3000);
            await SomeAsyncFunction(); // Here we are returning to the caller, the continuation will be executed either immediately because ther is no "await" in the main method.
            
            // All the rest won't be executed unless we execute MainRoutine in the secondary thread and call Thread.Join(secondaryThread) in Main() method.
            Thread.Sleep(3000);
            await SomeAsyncFunction();
            Thread.Sleep(3000);
            var finishedAt = DateTime.Now;
            Console.WriteLine((finishedAt - startedAt).TotalSeconds);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Threads
{
    public class CookClass
    {
        public async Task Process()
        {
            var onionTask = CutOnion()
                .ContinueWith(async task =>
                {
                    Console.WriteLine(task.Result);
                    return await CookOnion();
                }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(async task =>
                {
                    Console.WriteLine(task.Result.Result);
                    return await LookOnion();
                }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(async task =>
                {
                    Console.WriteLine(task.Result.Result);
                    return await LookOnionAgain();
                }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(async task =>
                 {
                     Console.WriteLine(task.Result.Result);
                 }, TaskContinuationOptions.OnlyOnRanToCompletion)
                ;
            var potatoTask = CutPotato()
                .ContinueWith(async task =>
                {
                    Console.WriteLine(task.Result);
                    return await PutPotatoIntoPan();
                }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(async task => Console.WriteLine(task.Result.Result), TaskContinuationOptions.OnlyOnRanToCompletion);

            Task.WaitAll(onionTask, potatoTask, PutWaterIntoPan());

            await WaitToWaterBoil();
        }

        private async Task<String> CutOnion()
        {
            await Task.Delay(1000);

            Console.WriteLine("Onion is cut");

            return "Ok";
        }

        private async Task<String> CookOnion()
        {
            await Task.Delay(1000);

            Console.WriteLine("Onion is cooked");

            return "Ok";
        }

        private async Task<String> LookOnion()
        {
            await Task.Delay(1000);

            Console.WriteLine("I looked it!");

            return "Ok";
        }

        private async Task<String> LookOnionAgain()
        {
            await Task.Delay(1000);

            Console.WriteLine("I looked it again!");

            return "Ok";
        }

        private async Task<String> CutPotato()
        {
            await Task.Delay(1000);

            Console.WriteLine("Potato is cut");

            return "Ok";
        }

        private async Task<String> PutPotatoIntoPan()
        {
            await Task.Delay(6000);

            Console.WriteLine("Potato is in the pan");

            return "Ok";
        }

        private async Task<String> PutWaterIntoPan()
        {
            await Task.Delay(1000);

            Console.WriteLine("Water is in the pan");

            return "Ok";
        }

        private async Task<String> WaitToWaterBoil()
        {
            await Task.Delay(500);

            Console.WriteLine("Water is boiled");

            return "Ok";
        }
    }
}

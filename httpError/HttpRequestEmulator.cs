using System;

namespace httpError
{
    public static class HttpRequestEmulator
    {
        public static void makeRequest()
        {
            var code = new Random().Next(400, 404);
            Console.WriteLine(new HTTPError(code,DateTime.Now));
            Logger.AddLog(code,DateTime.Now);
        }
    }
}
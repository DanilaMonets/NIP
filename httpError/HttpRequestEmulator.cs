using System;

namespace httpError
{
    /// <summary>
    /// Class emulating Http Request 
    /// </summary>
    public static class HttpRequestEmulator
    {
        
       /// <summary>
       /// Make a fake request and get a random Http Error
       /// </summary>
        public static void makeRequest()
        {
            var code = new Random().Next(400, 404);
            Console.WriteLine(new HTTPError(code,DateTime.Now));
            Logger.AddLog(code,DateTime.Now);
        }
    }
}
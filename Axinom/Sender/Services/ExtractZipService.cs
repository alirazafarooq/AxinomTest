using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Sender.Services
{
    public class ExtractZipService: IExtractZipService
    {
        private readonly string Username = "test";
        private readonly string Password = "test";

        public HttpStatusCode zipUpload(IFormFile file) 
        {
            string json = "";
            using (var stream = new MemoryStream((int)file.Length))
            {
                file.CopyTo(stream);
                var archive = new ZipArchive(stream);
                
                
                 
                         json = JsonConvert.SerializeObject(archive.Entries, Formatting.Indented, 
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
                
                return sendJson(json);
            }
            
        }

        public HttpStatusCode sendJson(string json) 
        {
            var url = "https://localhost:44362/api/zipfilecontent/filecontent";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Authorization"] = "Basic " + Base64Encode($"{Username}:{Password}");


            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                //string json1 = "\"{\\\"Entries\\\":[{\\\"Crc32\\\":0,\\\"CompressedLength\\\":0,\\\"ExternalAttributes\\\":16,\\\"FullName\\\":\\\"Proekspert-MyIoTService-main/\\\",\\\"LastWriteTime\\\":\\\"2022-05-08T23:38:56+03:00\\\",\\\"Length\\\":0,\\\"Name\\\":\\\"\\\"},{\\\"Crc32\\\":1976557095,\\\"CompressedLength\\\":2763,\\\"ExternalAttributes\\\":0,\\\"FullName\\\":\\\"Proekspert-MyIoTService-main/.gitignore\\\",\\\"LastWriteTime\\\":\\\"2022-05-08T23:38:56+03:00\\\",\\\"Length\\\":6150,\\\"Name\\\":\\\".gitignore\\\"},{\\\"Crc32\\\":0,\\\"CompressedLength\\\":0,\\\"ExternalAttributes\\\":16,\\\"FullName\\\":\\\"Proekspert-MyIoTService-main/Documentation/\\\",\\\"LastWriteTime\\\":\\\"2022-05-08T23:38:56+03:00\\\",\\\"Length\\\":0,\\\"Name\\\":\\\"\\\"}]}\"";
                streamWriter.Write(json);
            }
            try
            {
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                return HttpStatusCode.BadGateway;
            }
           

            //Console.WriteLine(httpResponse.StatusCode);
        }

        public static string Base64Encode(string textToEncode)
        {
            byte[] textAsBytes = Encoding.UTF8.GetBytes(textToEncode);
            return Convert.ToBase64String(textAsBytes);
        }
    }
        //public class FileInformation
        //{
        //   public string name { get; set; }
        //   public string mimeType { get; set; }
        //   public int size { get; set; }
        //}
    }
 
using System;

namespace API.Infra.Utils.Response
{
    public class FileResponse
    {
        public Object File { get; set; }

        public FileResponse(Object data)
        {
            this.File = data;
        }
    }
}
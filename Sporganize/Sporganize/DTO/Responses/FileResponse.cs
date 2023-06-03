﻿namespace Sporganize.DTO.Responses
{
    public class FileResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Type { get; set; }
        public byte[] Content { get; set; }

        public FileResponse(Models.File file) 
        {
            Id = file.Id;
            Name = file.Name;
            Extension = file.Extension;
            Type = file.Type;
            Content = file.Content;
        }

    }

}

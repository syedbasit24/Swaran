using Swaran.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SwaranSoft.Models
{
    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxSize;

        public FileSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return true;
            }

            if (file.ContentLength > _maxSize)
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} exceeds the maximum size of {_maxSize / 1024}KB.";
        }
    }

    public class FileTypesAttribute : ValidationAttribute
    {
        private readonly string[] _types;

        public FileTypesAttribute(string types)
        {
            _types = types.Split(',');
        }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return true;
            }

            var extension = System.IO.Path.GetExtension(file.FileName);

            return _types.Contains(extension.ToLowerInvariant());
        }

        public override string FormatErrorMessage(string name)
        {
            return $"Invalid file type for {name}. Allowed types are {string.Join(", ", _types)}.";
        }
    }
}

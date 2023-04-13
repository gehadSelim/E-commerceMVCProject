using System.ComponentModel.DataAnnotations;

namespace E_commerceMVCProject.Validations.ImageValidation
{
    public class ValidateFileAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int MaxContentLength = 1024 * 1024 * 5;
            string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".jpeg" };
            var files = value as IFormFileCollection;
            foreach (var file in files)
            {
                if (file == null)
                    return false;
                else if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                {
                    ErrorMessage = "Please upload Your Photo of type: " + string.Join(", ", AllowedFileExtensions);
                    return false;
                }
                else if (file.Length > MaxContentLength)
                {
                    ErrorMessage = "File is too large, maximum size is : " + (MaxContentLength / 1024).ToString() + "MB";
                    return false;
                }
                else
                    return true;
            }
            return false;
        }
    }
}

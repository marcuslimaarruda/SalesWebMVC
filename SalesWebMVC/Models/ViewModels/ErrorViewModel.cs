using System;

namespace SalesWebMVC.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        // Incluindo a propriedade menssage na classe criada pelo FrameWork.
        public string Messsage { get; set; }


        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
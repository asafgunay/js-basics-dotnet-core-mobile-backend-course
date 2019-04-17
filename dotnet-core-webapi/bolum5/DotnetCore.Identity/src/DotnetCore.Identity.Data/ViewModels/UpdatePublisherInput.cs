using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.Identity.Data.ViewModels
{
    public class UpdatePublisherInput : CreatePublisherInput
    {
        public int Id { get; set; }
    }
}

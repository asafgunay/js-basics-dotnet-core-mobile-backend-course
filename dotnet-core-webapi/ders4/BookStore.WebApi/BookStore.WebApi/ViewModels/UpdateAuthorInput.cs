﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.WebApi.ViewModels
{
    public class UpdateAuthorInput : CreateAuthorInput 
    {
        public int Id { get; set; }
    }
}

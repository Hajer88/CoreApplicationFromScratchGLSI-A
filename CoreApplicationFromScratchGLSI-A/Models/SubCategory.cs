﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplicationFromScratchGLSI_A.Models
{
    public class SubCategory
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int categoryId { get; set; }
        //Récupérer les sous cat d'une cat x
        public Category category { get; set; }
    }
}

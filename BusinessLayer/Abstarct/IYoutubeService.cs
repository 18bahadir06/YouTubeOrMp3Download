﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstarct
{
    public interface IYoutubeService
    {
        Task<string> ConvertYoutubeToMp3(string youtubeUrl);
    }
}

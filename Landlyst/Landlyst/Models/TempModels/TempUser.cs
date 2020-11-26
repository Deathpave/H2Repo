﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.Models.TempModels
{
    public class TempUser
    {
        private string initials;
        private int position;

        public TempUser(string Initials, int Position)
        {
            initials = Initials;
            position = Position;
        }

        public int Position
        {
            get { return position; }
            private set
            {
                if (position == 0)
                {
                    position = value;
                }
            }
        }

        public string Initials
        {
            get { return initials; }
            private set
            {
                if (initials == null || initials == string.Empty)
                {
                    initials = value;
                }
            }
        }

    }
}
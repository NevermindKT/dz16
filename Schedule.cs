﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Schedule
    {
        public int startTime { get; set; } = 7 * 60;
        public int endTime { get; set; } = 22 * 60;

        public int breakStart { get; set; } = 13 * 60;
        public int breakEnd { get; set; } = 14 * 60;

        public int patientStart { get; set; } = 6 * 60;
        public int patientEnd { get; set; } = 21 * 60;

        public bool isWorking(int currTime)
        {
            return currTime >= startTime && currTime < endTime &&
                !(currTime >= breakStart && currTime < breakEnd);
        }

        public bool isArriving(int currTime)
        {
            return currTime >= patientStart && currTime <= patientEnd;
        }
    }
}
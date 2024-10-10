﻿namespace Calculations
{
    //public class TimeSpan
    //{
    //    public int time;
    //    public string timeSpan;

    //    private string convertToTimeSpan(int time)
    //    {
    //        return $"{time / 60}:{time % 60}";
    //    }

    //    public TimeSpan(int time)
    //    {
    //        this.time = time;
    //        this.timeSpan = convertToTimeSpan(time);
    //    }
    //}

    public class Calculations
    {
        /// <summary>
        /// Метод для нахождения свободных периодов для консультаций
        /// </summary>
        /// <param name="startTimes">Начало периода</param>
        /// <param name="durations">Длительность консультации</param>
        /// <param name="beginWorkingTime">Начало рабочего дня</param>
        /// <param name="endWorkingTime">Конец рабочего дня</param>
        /// <param name="consultationTime">Минимально необходимое время консультации</param>
        /// <returns>Массив строк, представляющих временные промежутки</returns>
        public static string[] AvailablePeriods(string[] startTimes, int[] durations, string
        beginWorkingTime, string
        endWorkingTime, int consultationTime)
        {
            if (startTimes.Length == 0 || durations.Length == 0)
            {
                return null;
            }

            string[] result = { "08:00 - 08:30", "08:30 - 09:00", "09:00 - 09:30", "09:30 - 10:00", "11:30 - 12:00", "12:00 - 12:30", "12:30 - 13:00", "13:00 - 13:30", "13:30 - 14:00", "14:00 - 14:30", "14:30 - 15:00", "15:40 - 16:10", "16:10 - 16:40", "17:30 - 18:00" };
            return result;
        }
    }
}
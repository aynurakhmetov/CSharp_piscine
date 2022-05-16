using System;
using System.Collections.Generic;

// Значит нам нужен объект Habit, 
//     описывающий привычку: ее заголовок (Title) 
// и мотивацию поддержания трекинга (Motivation). 
//     Для привычки нужно будет вести прогресс: 
// его можно задать коллекцией объектов HabitCheck для каждого из планируемых дней трекинга, 
//     которые будут определяться свойствами Date и IsChecked. 
//     Как только все дни прошли (вне зависимости, были ли отмечены все из них), 
// трекинг завершен и это можно отметить в свойстве IsFinished.

namespace rush00.Data
{
    public class Habit
    {
        public string Title { get; set; }
        public string Motivation { get; set; }
        public List<HabitCheck> HabitCheckList { get; set; }
        public bool IsFinished { get; set; }
    }
}

using DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier
{
    public class Колледж
    {
        private List<ПозицияПреподавателей> _преподаватель = new List<ПозицияПреподавателей>();
        
        
        public Колледж()
        {
            List<Преподаватель> tmp = ВсеПреподаватели.ПолучитьВсеТовары();
            foreach (var t in tmp)
            {
                _преподаватель .Add(new ПозицияПреподавателей(t));
            }
        }
        public List<ПозицияПреподавателей> СписокПреподаватель
        {
            get { return _преподаватель; }
        }
        public String НаименованиеКолледжа
        {
            get { return "РКСИ"; }
        }
        public string Всегозадолжностейпокурсам
        {
            get
            {
                string s = "Курс ";
                
                for (int i = 1;i <=_преподаватель.Max(p=>p.КурсПреподаватель);i++)
                    switch(i== _преподаватель.Max(p => p.КурсПреподаватель))
                    {
                        case true: s += $"{i}:{_преподаватель.Where(p => p.КурсПреподаватель == i).Sum(p => p.ЗадолжностьПреподаватель)}."; break;
                        default:
                            s += $"{i}:{_преподаватель.Where(p => p.КурсПреподаватель == i).Sum(p => p.ЗадолжностьПреподаватель)}; "; break;
                    }
                
                return s;
            }
        }
        public int СтудентыбезЗадолжности
        {
            get
            {
                return _преподаватель.Count(p =>p.ЗадолжностьПреподаватель==0);
            }
        }
    }
}

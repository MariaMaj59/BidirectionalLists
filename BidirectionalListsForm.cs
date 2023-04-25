using System.Windows.Forms;

namespace BidirectionalLists
{
    class BiList
    {
        public int d;           // Значение элемента
        public BiList next;     // Указатель на следующий адрес
        public BiList pred;     // Указатель на предыдущий адрес

        // инициализация списка 
        /*
         nach - первый элемент списка, 
         end - последний элемент списка, 
         d - значение добавляемого элемента.
        */
        internal void Initial(out BiList end, out BiList nach, int d)
        {
            end = new BiList();
            end.next = null;
            end.pred = null;
            end.d = d;
            nach = end;   //перенести указатель nach на t
        }

        // Вывод списка с помощью адреса на «предыдущий» элемент 
        /*
        end - последний элемент списка.
        */
        internal string ShowPrev(BiList end)
        {
            string Show = "";
            for (BiList t = end; t != null; t = t.pred)
            {
                Show += t.d + " ";
            }
            return Show;
        }

        // Вывод списка с помощью адреса на «следующий» элемент
        /*
        nach - первый элемент списка.
        */
        internal string ShowNext(BiList nach)
        {
            string Show = "";
            for (BiList t2 = nach; t2 != null; t2 = t2.next) //t – текущий указатель (в конце списка)
            {
                Show += t2.d + " ";
            }
            return Show;
        }

        // Проверка на наличие элемента в списке и поиск элемента -  присваивает t ссылку на элемент, возвращает лощь если элемента нет
        /*
        nach - первый элемент списка, 
        t - элемент для сохранения ссылки на искомый элемент, 
        x - значение искомого элемента.
        */
        internal bool ElemChek(int x, BiList nach, ref BiList t)
        {
            t = nach;
            while (t != null && t.d != x)
                t = t.next;
            if (t == null)
                return false;
            else
                return true;
        }

        // Добавление элемента после заданного 
        /*
         nach - первый элемент списка, 
         t1 - элемент после которого идет добавление,
         x - значение добавляемого элемента,
         end - указатель на последний элемент списка.
        */
        internal void AddNext(BiList nach, BiList t1, int x, ref BiList end)
        {
            BiList t2;
            // создаем узел для вставки
            t2 = new BiList();
            t2.next = null;
            t2.pred = null;
            t2.d = x;

            if (t1.next == null) // если это последний элемент
            {
                // Связываем элементы
                t1.next = t2;
                t2.pred = t1;
                end = t2; // указатель на последний элемент списка ставим на добавляемый ("новый первый") элемент
            }
            else // если после него есть другие элементы
            {
                //связываем узлы:
                t1.next.pred = t2;
                t2.next = t1.next;
                t1.next = t2;
                t2.pred = t1;
            }
            t1 = t1.next;   
        }

        // Добавление элемента перед заданным 
        /*
         nach - первый элемент списка, 
         t1 - элемент перед которым идет добавление, 
         x - значение добавляемого элемента.
        */
        internal void AddPred(ref BiList nach, BiList t1, int x)
        {
            BiList t2;
            // создаем узел для вставки
            t2 = new BiList();
            t2.next = null;
            t2.pred = null;
            t2.d = x;

            if (t1.pred == null) // если это первый элемент
            {
                // связываем два узла 
                t1.pred = t2; 
                t2.next = t1; 
                nach = t2; // указатель на первый элемент списка ставим на добавляемый ("новый первый") элемент
            }
            else // если перед ним есть другие элементы
            {
                //связываем узлы:
                t1.pred.next = t2;
                t2.pred = t1.pred;
                t1.pred = t2;
                t2.next = t1;
            }
            t1 = t1.next;
        }

        // добавление нового элемента в конец
        /*
        end - последний элемент списка, 
        d - значение добавляемого элемента.
        */
        internal void Add(ref BiList end, int d)
        {
            BiList t1;
            // создаем узел для вставки
            t1 = new BiList();
            t1.next = null;
            t1.pred = null;
            t1.d = d;
            // связываем два узла (перемещаем указатели)
            end.next = t1; //следующее поле ("правое поле") первого элемента устанавливаем  на добавляемый элемент
            t1.pred = end; //предыдущее поле ("левое поле") добавляемого элемента устанавливаем на первый узел
            end = t1; // указатель на первый элемент списка ставим на добавляемый ("новый первый") элемент

        }

        // Удаление элемента 
        /*
         t1 - удаляемый элемент,
         end - последний элемент списка, 
         nach - первый элемент.
        */
        internal void DeleteShow(ref BiList t, ref BiList end, ref BiList nach)
        {
            BiList yd = t;// ставим указатель на предпоследний элемент
            // далить последний элемент, используя указатель, 
            // установленный на предпоследний узел списка: поле последнего элемента уставить в null
            if (yd.next == null)
            {
                end = yd.pred;
                yd.pred.next = null;
            }
            else if (yd.pred == null)
            {
                nach = yd.next;
                yd.next.pred = null;
            }
            else
            {
                yd.pred.next = yd.next;
                yd.next.pred = yd.pred;
            }

            yd.pred = null;
            yd.next = null;

            t = yd;
        }

        // Удаление всего списка
        /*
         nach - первый элемент.
        */
        internal void DeleteAll(BiList nach)
        {
            // ydw – создать вспомогательный указатель для удаления всех элементов списка  
            BiList ydw = nach;
            // До тех пор, пока не будут удалены все элементы - начинаем их по одному удалять	
            while (nach != null)
            {
                //перемещаем указатель начала списка - устанавливаем на второй элемент
                nach = ydw.next;
                //удаляем первый элемент
                ydw.next = null;
                ydw.pred = null;
                // указатель ydw позиционируем на "новый" первый элемент
                ydw = nach;
            }
            nach = null;//указатель на начало списка ставим в null
        }

    }
}

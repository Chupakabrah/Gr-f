using System;
using System.Collections.Generic;

namespace GrafFeladat_CSharp
{
    /// <summary>
    /// Irányítatlan, egyszeres gráf.
    /// </summary>
    class Graf
    {
        int csucsokSzama;
        /// <summary>
        /// A gráf élei.
        /// Ha a lista tartalmaz egy(A, B) élt, akkor tartalmaznia kell
        /// a(B, A) vissza irányú élt is.
        /// </summary>
        readonly List<El> elek = new List<El>();
        /// <summary>
        /// A gráf csúcsai.
        /// A gráf létrehozása után új csúcsot nem lehet felvenni.
        /// </summary>
        readonly List<Csucs> csucsok = new List<Csucs>();

        /// <summary>
        /// Létehoz egy úgy, N pontú gráfot, élek nélkül.
        /// </summary>
        /// <param name="csucsok">A gráf csúcsainak száma</param>
        public Graf(int csucsok)
        {
            this.csucsokSzama = csucsok;

            // Minden csúcsnak hozzunk létre egy új objektumot
            for (int i = 0; i < csucsok; i++)
            {
                this.csucsok.Add(new Csucs(i));
            }
        }

        /// <summary>
        /// Hozzáad egy új élt a gráfhoz.
        /// Mindkét csúcsnak érvényesnek kell lennie:
        /// 0 &lt;= cs &lt; csúcsok száma.
        /// </summary>
        /// <param name="cs1">Az él egyik pontja</param>
        /// <param name="cs2">Az él másik pontja</param>
        public void Hozzaad(int cs1, int cs2)
        {
            if (cs1 < 0 || cs1 >= csucsokSzama ||
                cs2 < 0 || cs2 >= csucsokSzama)
            {
                throw new ArgumentOutOfRangeException("Hibas csucs index");
            }

            // Ha már szerepel az él, akkor nem kell felvenni
            foreach (var el in elek)
            {
                if (el.Csucs1 == cs1 && el.Csucs2 == cs2)
                {
                    return;
                }
            }

            elek.Add(new El(cs1, cs2));
            elek.Add(new El(cs2, cs1));
        }

        public void Szelessegi(int sz_start)
        {
            var sz_bejart = new HashSet<int>();
            var sz_next = new Queue<int>();

            sz_next.Enqueue(sz_start);
            sz_bejart.Add(sz_start);

            while (sz_next.Count != 0)
            {
                var sz_nxt = sz_next.Dequeue();
                Console.WriteLine(this.csucsok[sz_nxt]);

                foreach (var sz_el in this.elek)
                {
                    if (sz_el.Csucs1 == sz_nxt && !sz_bejart.Contains(sz_el.Csucs2))
                    {
                        sz_next.Enqueue(sz_el.Csucs2);
                        sz_bejart.Add(sz_el.Csucs2);
                    }
                }
            }
        }

        public void Melysegi(int m_start)
        {
            var m_bejart = new HashSet<int>();
            var m_next = new Stack<int>();

            m_next.Push(m_start);
            m_bejart.Add(m_start);

            while (m_next.Count != 0)
            {
                var m_nxt = m_next.Pop();
                Console.WriteLine(this.csucsok[m_nxt]);

                foreach (var m_el in this.elek)
                {
                    if (m_el.Csucs1 == m_nxt && !m_bejart.Contains(m_el.Csucs2))
                    {
                        m_next.Push(m_el.Csucs2);
                        m_bejart.Add(m_el.Csucs2);
                    }
                }
            }
        }

        public Graf FeszFa()
        {
            var fa = new Graf(this.csucsokSzama);

            var fa_bejart = new HashSet<int>();
            var fa_next = new Queue<int>();

            fa_next.Enqueue(0);
            fa_bejart.Add(0);

            while (fa_next.Count != 0)
            {
                var fa_nxt = fa_next.Dequeue();

                foreach (var fa_el in this.elek)
                {
                    if (fa_el.Csucs1 == fa_nxt)
                    {
                        if (!fa_bejart.Contains(fa_el.Csucs2))
                        {
                            fa_bejart.Add(fa_el.Csucs2);
                            fa_next.Enqueue(fa_el.Csucs2);
                            fa.Hozzaad(fa_el.Csucs1, fa_el.Csucs2);
                        }
                    }
                }
            }
            return fa;
        }

        public bool Osszefuggo()
        {
            var o_bejart = new HashSet<int>();
            var o_next = new Queue<int>();

            o_next.Enqueue(0);
            o_bejart.Add(0);

            while (o_next.Count != 0)
            {
                var o_nxt = o_next.Dequeue();

                foreach (var o_el in this.elek)
                {
                    if (o_el.Csucs1 == o_nxt && !o_bejart.Contains(o_el.Csucs2))
                    {
                        o_next.Enqueue(o_el.Csucs2);
                        o_bejart.Add(o_el.Csucs2);
                    }
                }
            }

            if (o_bejart.Count == this.csucsok.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string str = "Csucsok:\n";
            foreach (var cs in csucsok)
            {
                str += cs + "\n";
            }
            str += "Elek:\n";
            foreach (var el in elek)
            {
                str += el + "\n";
            }
            return str;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Helpers
{
  public class LazyList<T, B> where B : class
  {
    private Dictionary<T, B> m_list = new Dictionary<T, B>();

    private Func<T, B> m_parser = null;

    public LazyList(Func<T, B> parser)
    {
      m_parser = parser;
    }

    public void Add(T item)
    {
      if (m_list.ContainsKey(item))
        throw new InvalidOperationException("The LazyList already contains the element that was tried to add.");

      m_list.Add(item, null);
    }

    private B this[T item] => GetLazy(item);

    private B GetLazy(T item)
    {
      if (!m_list.ContainsKey(item))
        throw new InvalidOperationException("The requested item could not be found.");

      if (m_list[item] == null)
        m_list[item] = m_parser(item);

      return m_list[item];
    }
  }
}

import java.lang.reflect.Array;

public class Stack<T>
    {
        private T []values;
        private int idx;

        public Stack(int limit, Class<T> c)
        {
			System.out.println(c.getName());
            values = (T[])Array.newInstance(c, limit);
            idx = 0;
        }

        public void Push(T i)
        {
            if (idx == values.length)
            {
                throw new IllegalStateException("Push on an full stack");
            }
            values[idx++] = i;
        }

        public T Pop()
        {
            if (idx == 0)
            {
                throw new IllegalStateException("Pop on an empty stack");
            }
            return values[--idx];
        }
		
		
		public static void main(String[] args) {
			Stack<Integer> si = new Stack<Integer>(10, Integer.class);
			
			
		}
    }
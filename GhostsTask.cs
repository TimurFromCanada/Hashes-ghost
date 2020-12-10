using System;
using System.Text;

namespace hashes
{
	public class GhostsTask :
		IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>,
		IMagic
	{
		static byte[] array = { 2, 4, 5 };
		Cat cat = new Cat("Муська", "Мэйнкун", new DateTime());
		Document document = new Document("Text", Encoding.UTF8, array);
		Robot robot = new Robot("Id", 1);
		Segment segment = new Segment(new Vector(1, 1), new Vector(2, 2));
		Vector vector = new Vector(1, 1);

		public void DoMagic()
		{
			cat.Rename("Васька");
			array[1]++;
			Robot.BatteryCapacity--;
			segment.End.Add(new Vector(2, 1));
			vector.Add(new Vector(1, 1));
		}

		// Чтобы класс одновременно реализовывал интерфейсы IFactory<A> и IFactory<B> 
		// придется воспользоваться так называемой явной реализацией интерфейса.
		// Чтобы отличать методы создания A и B у каждого метода Create нужно явно указать, к какому интерфейсу он относится.
		// На самом деле такое вы уже видели, когда реализовывали IEnumerable<T>.

		Vector IFactory<Vector>.Create()
		{
			return vector;
		}

		Segment IFactory<Segment>.Create()
		{
			return segment;
		}

		Document IFactory<Document>.Create()
		{
			return document;
		}

		Cat IFactory<Cat>.Create()
		{
			return cat;
		}

		Robot IFactory<Robot>.Create()
		{
			return robot;
		}
	}
}
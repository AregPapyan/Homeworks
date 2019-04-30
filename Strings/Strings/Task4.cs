using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
	class StudentComparer : Comparer<Student>
	{
		private static readonly StudentComparer instance = new StudentComparer();
		public static StudentComparer Instance { get { return instance; } }
		public override int Compare(Student x, Student y)
		{
			return x.AvgScore.CompareTo(y.AvgScore);
		}
	}
	class Student
	{
		private int avgScore;
		private int id;
		private string name;
		private Dictionary<string, int> testScores = new Dictionary<string, int>();
		public int AvgScore { get { return avgScore; } set { avgScore = value; } }
		public int Id { get { return id; } set { id = value; } }
		public string Name { get { return name; } set { name = value; } }
		public Dictionary<string, int> TestScores { get { return testScores; } set { testScores = value; } }
		public void AddTestResult(string subject, int score)
		{
			this.testScores.Add(subject, score);
		}
		public Student()
		{

		}
		public Student(int id, string name)
		{
			this.id = id;
			this.name = name;
		}
		public Student(int avgScore, int id, string name)
		{
			this.avgScore = avgScore;
			this.id = id;
			this.name = name;
		}
	}
	class StudentCatalog
	{
		private int sum = 0, counter = 0;
		private Dictionary<int, Student> students = new Dictionary<int, Student>();
		public Dictionary<int, Student> Students { get { return students; } set { students = value; } }
		public void AddStudent(Student aStudent)
		{
			this.students.Add(aStudent.Id, aStudent);
		}
		public Student GetStudent(int id)
		{
			if (this.students.ContainsKey(id))
				return this.students[id];
			else
				return null;
		}
		public int GetAverageForStudent(int id)
		{
			if (this.students.ContainsKey(id))
			{
				this.sum = 0; this.counter = 0;
				foreach (KeyValuePair<string, int> item in this.students[id].TestScores)
				{
					this.sum += item.Value;
					this.counter++;
				}
				if (this.counter > 0)
					return this.sum / this.counter;
				else
					return -1;
			}
			else
				return -1;
		}
		public int GetTotalAverage()
		{
			this.sum = 0; this.counter = 0;
			foreach (KeyValuePair<int, Student> studentIterator in this.students)
			{
				foreach (KeyValuePair<string, int> iterator in studentIterator.Value.TestScores)
				{
					this.sum += iterator.Value;
					this.counter++;
				}
			}
			if (counter > 0)
				return this.sum / this.counter;
			else
				return -1;
		}
		public List<Student> GetTopThreeStudents()
		{
			List<Student> studentsWithScores = new List<Student>();
			foreach (KeyValuePair<int, Student> item in this.students)
			{
				Student st = new Student(GetAverageForStudent(item.Key), item.Key, item.Value.Name);
				if(st.AvgScore>0)
					studentsWithScores.Add(st);
			}
			if (studentsWithScores.Count >= 3)
			{
				studentsWithScores.Sort(StudentComparer.Instance);
				studentsWithScores.Reverse();
				List<Student> topStudentsWithScores = new List<Student>();
				topStudentsWithScores.Add(studentsWithScores[0]);
				topStudentsWithScores.Add(studentsWithScores[1]);
				topStudentsWithScores.Add(studentsWithScores[2]);
				return topStudentsWithScores;
			}
			else
			{
				studentsWithScores.Clear();
				return studentsWithScores;
			}
		}
	}
	class Task4
	{
		static void Main(string[] args)
		{	
			
		}
	}
}
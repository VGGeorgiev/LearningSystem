import { Lecture } from "./lecture";

export class Course {
  id: number;
  name: string;
}

export class CourseInput extends Course {
  credits: number;
  semesterId: number;
}

export class CourseDetail extends Course {
  lectures: Lecture[];
}

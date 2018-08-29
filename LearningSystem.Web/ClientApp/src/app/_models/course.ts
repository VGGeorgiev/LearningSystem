import { Lecture } from "./lecture";

export class Course {
  id: number;
  name: string;
}

export class CourseDetail extends Course {
  lectures: Lecture[];
}

import { Course } from "./course";

export class SemesterInput {
  id: number;
  name: string;
}

export class Semester extends SemesterInput {
  courses: Course[];
}

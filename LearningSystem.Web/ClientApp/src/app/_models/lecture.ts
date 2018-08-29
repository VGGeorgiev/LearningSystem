import { HomeworkAssignment } from "./homeworkAssignment";

export class Lecture {
  id: number;
  name: string;
  videoUrl: string;
  homeworkAssignments: HomeworkAssignment[];
}

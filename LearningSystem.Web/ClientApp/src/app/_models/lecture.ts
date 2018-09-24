import { HomeworkAssignment } from "./homeworkAssignment";
import { SafeResourceUrl } from "@angular/platform-browser";

export class Lecture {
  id: number;
  name: string;
  description: string;
  videoUrl: string;
  safeVideoUrl: SafeResourceUrl;
  homeworkAssignments: HomeworkAssignment[];
}

export class LectureInput {
  id: number;
  name: string;
  description: string;
  videoUrl: string;
  courseId: number;
}

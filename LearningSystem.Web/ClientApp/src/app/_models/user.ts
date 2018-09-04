import { Feedback } from "./feedback";

export class User {
  id: number;
  username: string;
  password: string;
  firstName: string;
  lastName: string;
}

export class UserDetail extends User {
  feedbacks: Feedback[];
}

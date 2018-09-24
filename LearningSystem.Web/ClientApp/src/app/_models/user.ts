export enum UserType {
  User,
  Student,
  Trainer
}

export class UserInput {
  id: number;
  username: string;
  firstName: string;
  lastName: string;
  type: UserType;
}

export class User extends UserInput {
  password: string;
}

export class UserInCourse {
  id: number;
  courseName: string;
  grade: number;
}

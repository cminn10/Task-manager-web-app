import { Task } from "./task";

export interface User {
    id: number
    email: string
    fullname: string
    mobileno: string
    tasks: Task[]
    tasksHistories: History[]
}
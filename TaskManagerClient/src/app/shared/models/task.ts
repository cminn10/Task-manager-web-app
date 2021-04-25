import { User } from "./user";

export interface Task {
    id: number
    userId: number
    title: string
    description: string
    dueDate: Date
    priority: string
    remarks: string
    user: User
    completed: Date
}
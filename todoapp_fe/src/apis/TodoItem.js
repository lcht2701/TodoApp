import axios from "axios";
import { baseURL } from "./link";

export async function getAllTodoItemList() {
  try {
    const res = await axios.get(`${baseURL}/ToDoItem`);
    return res.data;
  } catch (error) {
    console.log(error);
  }
}

export async function getTodoItem(id) {
  try {
    const res = await axios.get(`${baseURL}/ToDoItem/${id}`);
    return res.data;
  } catch (error) {
    console.log(error);
  }
}

export async function CreateToDoItem(data) {
  try {
    const res = await axios.post(`${baseURL}/ToDoItem`, data);
    return res.data;
  } catch (error) {
    console.log(error);
  }
}

export async function UpdateToDoItem(id, data) {
  try {
    const res = await axios.patch(`${baseURL}/ToDoItem/${id}`, data);
    return res.data;
  } catch (error) {
    console.log(error);
  }
}

export async function DeleteToDoItem(id) {
  try {
    const res = await axios.delete(`${baseURL}/ToDoItem/${id}`);
    return res.data;
  } catch (error) {
    console.log(error);
  }
}

import React, { useState } from "react";
import { Priority, Status } from "../constants/EnumData";
import moment from "moment";

export const EditTodoForm = () => {
  const currentDateTime = moment(Date.now()).format("YYYY-MM-DD hh:mm:ss");
  const [data, setData] = useState({
    title: "",
    description: "",
    dueBy: currentDateTime,
    status: "",
    priority: "",
  });
  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };
  const handleSubmit = (event) => {
    event.preventDefault(); // Prevent the default form submission
    // Validate inputs
    // Do something with the form data, like sending it to a backend server
    console.log(data);
  };
  return (
    <form className="createTodoForm" onSubmit={handleSubmit}>
      <div className="form-group">
        <label className="form-label">Title</label>
        <input
          name="title"
          value={data.title}
          onChange={handleInputChange}
          type="text"
          placeholder="Title..."
          className="form-control"
        />
      </div>
      <div className="form-group">
        <label className="form-label">Description</label>
        <input
          name="description"
          value={data.description}
          onChange={handleInputChange}
          type="text"
          placeholder="Description..."
          className="form-control"
        />
      </div>
      <div className="form-group">
        <label className="form-label">Due By</label>
        <input
          name="dueBy"
          value={data.dueBy}
          onChange={handleInputChange}
          type="datetime-local"
          placeholder="Due By..."
          className="form-control"
        />
      </div>
      <div className="form-group">
        <label className="form-label">Status</label>
        <select
          name="status"
          value={data.status}
          onChange={handleInputChange}
          className="form-control"
        >
          <option value="">Select a Status...</option>
          {Object.entries(Status).map(([key, value]) => (
            <option key={key} value={key}>
              {value}
            </option>
          ))}
        </select>
      </div>
      <div className="form-group">
        <label className="form-label">Priority</label>
        <select
          name="priority"
          value={data.priority}
          onChange={handleInputChange}
          className="form-control"
        >
          <option value="">Select Priority...</option>
          {Object.entries(Priority).map(([key, value]) => (
            <option key={key} value={key}>
              {value}
            </option>
          ))}
        </select>
      </div>
      <input type="submit" className="btn" value="Create" />
    </form>
  );
};

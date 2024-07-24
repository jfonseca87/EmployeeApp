import React from "react";
import { Table, Image } from "react-bootstrap";

const EmployeeTable = ({ employees = [] }) => {
  const formatCurrency = (value) => {
    return Number(value).toLocaleString("en-US", {
      style: "currency",
      currency: "USD",
    });
  };

  return employees.length === 0 ? (
    <div>There are not employees</div>
  ) : (
    <Table striped bordered hover>
      <thead>
        <tr>
          <th>Name</th>
          <th>Age</th>
          <th>Month Salary</th>
          <th>Annual Salary</th>
          <th>Profile Photo</th>
        </tr>
      </thead>
      <tbody>
        {employees.map((employee, index) => (
          <tr key={index}>
            <td>{employee.name}</td>
            <td>{employee.age}</td>
            <td>{formatCurrency(employee.salary)}</td>
            <td>{formatCurrency(employee.annualSalary)}</td>
            <td>
              {employee.ProfileImage && (
                <Image
                  src={employee.profileImage}
                  roundedCircle
                  style={{ width: "50px", height: "50px" }}
                />
              )}
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  );
};

export default EmployeeTable;

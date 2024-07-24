import { useEffect, useState } from "react";
import Searcher from "./components/Searcher";
import EmployeeTable from "./components/EmployeeTable";
import { fetchData } from "./services/fetchData";
import "./App.css";

const getEmployees = async () => {
  try {
    const data = await fetchData("employees");
    return data;
  } catch (error) {
    console.error("Error fetching employees:", error);
  }
};

const getEmployeeById = async (employeeId) => {
  try {
    const data = await fetchData(`employees/${employeeId}`);
    return data;
  } catch (error) {
    console.error("Error fetching employees:", error);
  }
};

function App() {
  const [employees, setEmployees] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");

  useEffect(() => {
    const fetchDataBasedOnSearchTerm = async () => {
      try {
        if (searchTerm !== "") {
          const data = await getEmployeeById(searchTerm);
          setEmployees(data ? [data] : []);
        } else {
          const data = await getEmployees();
          setEmployees(data);
        }
      } catch (error) {
        // Manejar errores de forma adecuada según el contexto de la aplicación
        console.error("Error in useEffect:", error);
      }
    };

    fetchDataBasedOnSearchTerm();
  }, [searchTerm]);

  const handleSearch = (searchTerm) => {
    debugger;
    console.log(searchTerm);
    if (isNaN(+searchTerm)) {
      return;
    }

    setSearchTerm(searchTerm);
  };

  return (
    <div className="container">
      <h1 className="mb-5">Employee List 1.0</h1>
      <div className="row mb-4">
        <div className="col">
          <Searcher onSearch={handleSearch} />
        </div>
      </div>
      <div className="row">
        <div className="col">
          <EmployeeTable employees={employees} />
        </div>
      </div>
    </div>
  );
}

export default App;

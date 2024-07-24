import React, { useState } from "react";
import { FormControl, Button, InputGroup } from "react-bootstrap";

const Searcher = ({ onSearch }) => {
  const [searchTerm, setSearchTerm] = useState("");

  const handleChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const handleSearch = () => {
    onSearch(searchTerm);
  };

  return (
    <>
      <InputGroup className="mb-3">
        <FormControl
          placeholder="Buscar..."
          value={searchTerm}
          onChange={handleChange}
          aria-label="Buscar"
          aria-describedby="basic-addon2"
        />
        <Button variant="outline-secondary" onClick={handleSearch} >Buscar</Button>
      </InputGroup>
    </>
  );
};

export default Searcher;

const BASE_URL = 'http://localhost:5187/api'; // Reemplaza con la URL de tu API

const fetchData = async (url) => {
  try {
    const response = await fetch(`${BASE_URL}/${url}` );
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    const data = await response.json();
    return data;
  } catch (error) {
    console.error('Error fetching data:', error);
    throw error;
  }
};

export { fetchData };
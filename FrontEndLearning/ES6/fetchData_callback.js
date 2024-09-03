function fetchData(url, callback) {
  console.log(`Fetching data from ${url}...`);
  setTimeout(() => {
    const data = `Data from ${url}`;
    callback(data);
  }, 2000);
}

fetchData('https://www.google.com/', (data) => {
  console.log(data);
});

function fetchData(url) {
  return new Promise((resolve, reject) => {
    if (url) {
      setTimeout(() => {
        console.log('When valid URL');
        resolve(`Data from ${url}`);
      }, 2000);
    } else {
      console.log('When url is empty or nor provide:');
      reject(`Invalid URL`);
    }
  });
}

function callFetchData(url) {
  fetchData(url).then(
    (result) => {
      console.log(result); //When valid URL:\nData from ${url}
    },
    (error) => {
      console.error(error); //When url is empty or nor provide:\nInvalid URL
    }
  );
}

callFetchData();
callFetchData('https://www.google.com/');

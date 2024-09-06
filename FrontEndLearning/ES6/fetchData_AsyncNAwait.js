function fetchData(url) {
  return new Promise((resolve, reject) => {
    if (url) {
      setTimeout(() => {
        console.log('When valid URL');
        resolve(`Data from ${url}`);
      }, 2000);
    } else {
      console.log(`When url is empty or nor provide:`);
      reject(`Invalid URL`);
    }
  });
}

async function loadData(url) {
  try {
    const result = await fetchData(url);
    console.log(result);
  } catch (error) {
    console.error(error);
  }
}

// await loadData('');
// error: await is only valid in async functions and the top level bodies of modules
loadData(''); // must has await
// await loadData('https://www.google.com/');
// error: await is only valid in async functions and the top level bodies of modules
loadData('https://www.google.com/'); //await loadData('https://www.google.com/'); must has await

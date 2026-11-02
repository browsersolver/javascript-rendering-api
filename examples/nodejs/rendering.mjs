// JavaScript Rendering API – Node.js example (Node 18+, ES module)
// Usage: BROWSERSOLVER_API_KEY=your-key node rendering.mjs

const headers = { "x-api-key": process.env.BROWSERSOLVER_API_KEY, "Content-Type": "application/json" };

const params = new URLSearchParams({
  "query": "https://quotes.toscrape.com/js/",
});
const response = await fetch(`https://api.browsersolver.com/v1/website/rendering?${params}`, { headers });
if (!response.ok) {
  console.error(`HTTP ${response.status}: ${await response.text()}`);
  process.exit(1);
}

console.log(JSON.stringify(await response.json(), null, 2));

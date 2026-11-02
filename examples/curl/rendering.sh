#!/usr/bin/env bash
# JavaScript Rendering API – cURL example
# Usage: BROWSERSOLVER_API_KEY=your-key bash rendering.sh
set -euo pipefail

curl -sS -G "https://api.browsersolver.com/v1/website/rendering" \
  -H "x-api-key: ${BROWSERSOLVER_API_KEY}" \
  --data-urlencode query=https://quotes.toscrape.com/js/

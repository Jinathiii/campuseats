// The API base URL is read from the environment, so the same code works locally
// and in production. Vite bakes VITE_* values in at build time.
const API = import.meta.env.VITE_API_URL;

export async function getMenu() {
  if (!API) throw new Error('VITE_API_URL is not set')
  const res = await fetch(`${API}/api/menu`)
  if (!res.ok) throw new Error(`API returned ${res.status}`)
  return res.json()
}

export const apiUrl = API

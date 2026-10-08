import { useEffect, useState } from 'react'
import { getMenu, apiUrl } from './api.js'

const formatPrice = (p) => `Rs. ${Number(p).toFixed(2)}`

function App() {
  const [items, setItems] = useState([])
  const [status, setStatus] = useState('loading')
  const [error, setError] = useState('')
  const [category, setCategory] = useState('All')

  useEffect(() => {
    getMenu()
      .then((data) => {
        setItems(data)
        setStatus('ready')
      })
      .catch((err) => {
        setError(err.message)
        setStatus('error')
      })
  }, [])

  const categories = ['All', ...new Set(items.map((i) => i.category))]
  const visible = category === 'All' ? items : items.filter((i) => i.category === category)

  return (
    <div className="page">
      <header className="header">
        <h1>CampusEats</h1>
        <p>Order from the campus canteen without the queue.</p>
      </header>

      <main>
        {status === 'loading' && <p className="note">Loading menu… (a sleeping free-tier API can take ~30s to wake)</p>}
        {status === 'error' && (
          <p className="note error">Could not load the menu: {error}</p>
        )}

        {status === 'ready' && (
          <>
            <nav className="tabs">
              {categories.map((c) => (
                <button
                  key={c}
                  className={c === category ? 'tab active' : 'tab'}
                  onClick={() => setCategory(c)}
                >
                  {c}
                </button>
              ))}
            </nav>
            <ul className="grid">
              {visible.map((item) => (
                <li key={item.id} className="card">
                  <span className="cat">{item.category}</span>
                  <h2>{item.name}</h2>
                  <p>{item.description}</p>
                  <strong>{formatPrice(item.price)}</strong>
                </li>
              ))}
            </ul>
          </>
        )}
      </main>

      <footer className="footer">
        API: <code>{apiUrl || 'not configured'}</code> · build mode: <code>{import.meta.env.MODE}</code>
      </footer>
    </div>
  )
}

export default App

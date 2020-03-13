import React, { useState, useEffect } from 'react'

function App() {
  const [repositories, setRepositories] = useState([])
  const [location, setLocation] = useState({})

  useEffect(() => {
    const watchId = navigator.geolocation.watchPosition(handlePositionReceived)

    return () => navigator.geolocation.clearWatch(watchId) //Executed when the component will be unmounted
  }, [])

  function handlePositionReceived({ coords }){

    const { latitude, longitude } = coords

    setLocation({ latitude, longitude })
  }

  /* I (useEffect) just want to execute when the variables inside the array changes */
  /* If the array is empty, useEffect will execute once */
  useEffect(async () => {
    const response = await fetch('https://api.github.com/users/gumberss/repos')
    const data = await response.json()

    setRepositories(data)
  }, [])

  useEffect(() => {
    const filtered = repositories.filter(repo => repo.favorite)
    document.title = `Você tem ${filtered.length} favoritos`
  }, [repositories])

  function handleFavorite(id) {
    const newRepositories = repositories.map(repo =>
      repo.id == id ? { ...repo, favorite: !repo.favorite } : repo
    )

    setRepositories(newRepositories)
  }

  return (
    <>
    <div>
      Olá usuário.<br />
      Você está em: <br />
      Latitude: { location.latitude }<br />
      Longitude: { location.longitude }
      
    </div>
      <ul>
        {repositories.map(repo => (
          <li key={repo.id}>
            {repo.name}
            {repo.favorite && <span>Favorito</span>}
            <button onClick={() => handleFavorite(repo.id)}> Favoritar</button>
          </li>

        ))}
      </ul>
    </>
  )
}

export default App;

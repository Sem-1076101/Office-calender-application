// src/App.tsx
import Layout from './components/common/Layout/Layout';
import Hero from './components/common/Hero/Hero';

function App() {
    return (
        <Layout>
            <Hero
                title="Office Calendar"
                subtitle="Plan your workweek and events in one place."
                backgroundImage="/src/assets/images/hero-background.png"
                height="500px"
            />
        </Layout>
    );
}

export default App;
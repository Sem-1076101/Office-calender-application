// src/components/common/Layout/Layout.tsx
import { Container } from 'react-bootstrap';
import Header from '../Header/Header';
import Footer from '../Footer/Footer';

interface LayoutProps {
    children: React.ReactNode;
}

const Layout = ({ children }: LayoutProps) => {
    return (
        <div className="d-flex flex-column min-vh-100">
            <Header />
            <Container fluid className="flex-grow-1 py-4">
                {children}
            </Container>
            <Footer />
        </div>
    );
};

export default Layout;
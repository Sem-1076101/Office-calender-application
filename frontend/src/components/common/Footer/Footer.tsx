// src/components/common/Footer/Footer.tsx
import React from 'react';
import { Container } from 'react-bootstrap';

const Footer: React.FC = () => {
    return (
        <footer className="bg-dark text-light py-3 mt-auto">
            <Container>
                <p className="mb-0 text-center">© 2025 Office Calendar App</p>
            </Container>
        </footer>
    );
};

export default Footer;
// src/components/common/Header/Header.tsx
import { Navbar, Container, Nav } from 'react-bootstrap';

const Header = () => {
    return (
        <Navbar bg="dark" variant="dark" expand="lg">
            <Container fluid>
                <Navbar.Brand href="/">Office Calendar App</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ms-auto">
                        <Nav.Link href="/dashboard">Dashboard</Nav.Link>
                        <Nav.Link href="/medewerkers">Medewerkers</Nav.Link>
                        <Nav.Link href="/evenementen">Evenementen</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
};

export default Header;
// src/components/common/Hero/Hero.tsx
interface HeroProps {
    title?: string;
    subtitle?: string;
    backgroundImage?: string;
    height?: string;
}

const Hero = ({ title, subtitle, backgroundImage, height }: HeroProps) => {
    return (
        <div
            className="hero-section position-relative d-flex align-items-center"
            style={{
                minHeight: height || '400px',
                backgroundImage: backgroundImage ? `url(${backgroundImage})` : undefined,
                backgroundSize: 'cover',
                backgroundPosition: 'center',
                backgroundRepeat: 'no-repeat'
            }}
        >
            {/* Overlay */}
            <div
                className="position-absolute top-0 start-0 w-100 h-100"
                style={{ backgroundColor: 'rgba(0, 0, 0, 0.5)' }}
            />

            {/* Content - alleen tonen als er title of subtitle is */}
            {(title || subtitle) && (
                <div className="container position-relative text-white text-center">
                    {title && <h1 className="display-3 fw-bold mb-3">{title}</h1>}
                    {subtitle && <p className="lead fs-4">{subtitle}</p>}
                </div>
            )}
        </div>
    );
};

export default Hero;
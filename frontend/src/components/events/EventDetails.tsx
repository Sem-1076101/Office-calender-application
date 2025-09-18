import { useParams } from 'react-router-dom';
import NotFound from '../common/NotFound/NotFound';
import { useEffect } from 'react';
import '/src/components/events/EventDetail.scss';
interface Evenement {
  id?: number;
  name?: string;
  description?: string;
  date: string;
  place: string;

}

const evenementen: Evenement[] = [
  { id: 1, name: "evenement", description: "This is the description for event 1.", place: "rotterdam", date: "30/09/2025"},
  { id: 2, name: "evenement", description: "This is the description for event 2.", place: "online", date: "30/09/2025"},
  { id: 3, name: "evenement", description: "This is the description for event 3.", place: "online", date: "30/09/2025"},
  { id: 4, name: "evenement", description: "This is the description for event 4.", place: "online", date: "30/09/2025"},
  { id: 5, name: "evenement", description: "This is the description for event 5.", place: "online", date: "30/09/2025"},
  { id: 6, name: "evenement", description: "This is the description for event 6.", place: "online", date: "30/09/2025"},
  { id: 7, name: "evenement", description: "This is the description for event 7.", place: "online", date: "30/09/2025"},
  { id: 8, name: "evenement", description: "This is the description for event 8.", place: "online", date: "30/09/2025"},
  { id: 9, name: "evenement", description: "This is the description for event 9.", place: "online", date: "30/09/2025"},
];

const Event = () => {
    useEffect(() => {
            window.scrollTo(610, 610);
        });
    const { id } = useParams<{ id: string}>();
    const event = evenementen.find(e => e.id === Number(id));
    if(!event) {
        return <NotFound />;
    }
  return (
    <div className="main">
        <div className="Border-line"></div>
        <div className="inner"></div>
        <div key={event.id} className="main-card">
            <h1 className="event-id-detail">{event.id}</h1>
            <h2 className="event-name-detail">{event.name}</h2>
            <div className="underscore"></div>
            <p className="event-description-detail">{event.description}</p>
            <p className="place">PLACE</p>
            <div className="place-outer">
                <div className="place-inner">
                    <p className="actual-place">{event.place}</p>
                </div>
            </div>
            <p className="date">DATE</p>
            <div className="date-outer">
                <div className="date-inner">
                    <p className="actual-date">{event.date}</p>
                </div>
            </div>
        </div>
    </div>
  );
};

export default Event;
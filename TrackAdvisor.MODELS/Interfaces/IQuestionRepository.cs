using TrackAdvisor.MODELS;

namespace TrackAdvisor.MODELS.Interfaces
{
    public interface IQuestionRepository
    {
        // Save a new question to the database
        bool Save(Question question);

        // Get all questions by topic
        List<Question> FindByTopicID(int topicId);

        // Delete a question by ID
        void Delete(int id);
    }
}
